﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Graph.RBAC;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Fluent.Graph.RBAC;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;

namespace Microsoft.Azure.Management.Fluent.KeyVault
{
    public class KeyVaultManager : ManagerBase, IKeyVaultManager
    {
        private IGraphRbacManager graphRbacManager;
        private string tenantId;

        #region SDK clients
        private KeyVaultManagementClient client;
        #endregion

        #region Fluent private collections
        private IVaults vaults;
        #endregion

        #region ctrs

        public KeyVaultManager(RestClient restClient, string subscriptionId, string tenantId) : base(restClient, subscriptionId)
        {
            client = new KeyVaultManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
            graphRbacManager = GraphRbacManager.Authenticate(restClient.Credentials, subscriptionId, tenantId);
            this.tenantId = tenantId;
        }

        #endregion

        #region Key Vault Manager builder

        public static IKeyVaultManager Authenticate(ServiceClientCredentials serviceClientCredentials, string subscriptionId, string tenantId)
        {
            return new KeyVaultManager(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(serviceClientCredentials)
                    .build(), subscriptionId, tenantId);
        }

        public static IKeyVaultManager Authenticate(AzureCredentials azureCredentials, string subscriptionId)
        {
            return new KeyVaultManager(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(azureCredentials)
                    .build(), subscriptionId, azureCredentials.TenantId);
        }

        public static IKeyVaultManager Authenticate(RestClient restClient, string subscriptionId, string tenantId)
        {
            return new KeyVaultManager(restClient, subscriptionId, tenantId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IKeyVaultManager Authenticate(ServiceClientCredentials serviceClientCredentials, string subscriptionId, string tenantId);

            IKeyVaultManager Authenticate(AzureCredentials azureCredentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {

            public IKeyVaultManager Authenticate(ServiceClientCredentials credentials, string subscriptionId, string tenantId)
            {
                return new KeyVaultManager(BuildRestClient(credentials), subscriptionId, tenantId);
            }

            public IKeyVaultManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new KeyVaultManager(BuildRestClient(credentials), subscriptionId, credentials.TenantId);
            }
        }

        #endregion

        #region IKeyVaultManager implementation 

        public IVaults Vaults
        {
            get
            {
                if (vaults == null)
                {
                    vaults = new VaultsImpl(
                        client.Vaults,
                        this,
                        graphRbacManager,
                        tenantId);
                }

                return vaults;
            }
        }
        
        #endregion
    }

    public interface IKeyVaultManager : IManagerBase
    {
        IVaults Vaults { get; }
    }
}