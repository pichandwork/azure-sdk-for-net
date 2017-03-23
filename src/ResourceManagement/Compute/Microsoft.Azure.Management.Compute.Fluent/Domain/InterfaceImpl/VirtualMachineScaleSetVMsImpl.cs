// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    internal partial class VirtualMachineScaleSetVMsImpl 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>.List()
        {
            return this.List() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>;
        }
    }
}