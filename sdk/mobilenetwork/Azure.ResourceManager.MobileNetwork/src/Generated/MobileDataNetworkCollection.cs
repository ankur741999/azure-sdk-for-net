// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.MobileNetwork
{
    /// <summary>
    /// A class representing a collection of <see cref="MobileDataNetworkResource" /> and their operations.
    /// Each <see cref="MobileDataNetworkResource" /> in the collection will belong to the same instance of <see cref="MobileNetworkResource" />.
    /// To get a <see cref="MobileDataNetworkCollection" /> instance call the GetMobileDataNetworks method from an instance of <see cref="MobileNetworkResource" />.
    /// </summary>
    public partial class MobileDataNetworkCollection : ArmCollection, IEnumerable<MobileDataNetworkResource>, IAsyncEnumerable<MobileDataNetworkResource>
    {
        private readonly ClientDiagnostics _mobileDataNetworkDataNetworksClientDiagnostics;
        private readonly DataNetworksRestOperations _mobileDataNetworkDataNetworksRestClient;

        /// <summary> Initializes a new instance of the <see cref="MobileDataNetworkCollection"/> class for mocking. </summary>
        protected MobileDataNetworkCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MobileDataNetworkCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MobileDataNetworkCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mobileDataNetworkDataNetworksClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.MobileNetwork", MobileDataNetworkResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MobileDataNetworkResource.ResourceType, out string mobileDataNetworkDataNetworksApiVersion);
            _mobileDataNetworkDataNetworksRestClient = new DataNetworksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, mobileDataNetworkDataNetworksApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != MobileNetworkResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, MobileNetworkResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a data network. Must be created in the same location as its parent mobile network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/mobileNetworks/{mobileNetworkName}/dataNetworks/{dataNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataNetworks_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="dataNetworkName"> The name of the data network. </param>
        /// <param name="data"> Parameters supplied to the create or update data network operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataNetworkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataNetworkName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MobileDataNetworkResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string dataNetworkName, MobileDataNetworkData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataNetworkName, nameof(dataNetworkName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mobileDataNetworkDataNetworksClientDiagnostics.CreateScope("MobileDataNetworkCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mobileDataNetworkDataNetworksRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataNetworkName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MobileNetworkArmOperation<MobileDataNetworkResource>(new MobileDataNetworkOperationSource(Client), _mobileDataNetworkDataNetworksClientDiagnostics, Pipeline, _mobileDataNetworkDataNetworksRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataNetworkName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a data network. Must be created in the same location as its parent mobile network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/mobileNetworks/{mobileNetworkName}/dataNetworks/{dataNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataNetworks_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="dataNetworkName"> The name of the data network. </param>
        /// <param name="data"> Parameters supplied to the create or update data network operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataNetworkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataNetworkName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MobileDataNetworkResource> CreateOrUpdate(WaitUntil waitUntil, string dataNetworkName, MobileDataNetworkData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataNetworkName, nameof(dataNetworkName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mobileDataNetworkDataNetworksClientDiagnostics.CreateScope("MobileDataNetworkCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mobileDataNetworkDataNetworksRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataNetworkName, data, cancellationToken);
                var operation = new MobileNetworkArmOperation<MobileDataNetworkResource>(new MobileDataNetworkOperationSource(Client), _mobileDataNetworkDataNetworksClientDiagnostics, Pipeline, _mobileDataNetworkDataNetworksRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataNetworkName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about the specified data network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/mobileNetworks/{mobileNetworkName}/dataNetworks/{dataNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataNetworks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dataNetworkName"> The name of the data network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataNetworkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataNetworkName"/> is null. </exception>
        public virtual async Task<Response<MobileDataNetworkResource>> GetAsync(string dataNetworkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataNetworkName, nameof(dataNetworkName));

            using var scope = _mobileDataNetworkDataNetworksClientDiagnostics.CreateScope("MobileDataNetworkCollection.Get");
            scope.Start();
            try
            {
                var response = await _mobileDataNetworkDataNetworksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataNetworkName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MobileDataNetworkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about the specified data network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/mobileNetworks/{mobileNetworkName}/dataNetworks/{dataNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataNetworks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dataNetworkName"> The name of the data network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataNetworkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataNetworkName"/> is null. </exception>
        public virtual Response<MobileDataNetworkResource> Get(string dataNetworkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataNetworkName, nameof(dataNetworkName));

            using var scope = _mobileDataNetworkDataNetworksClientDiagnostics.CreateScope("MobileDataNetworkCollection.Get");
            scope.Start();
            try
            {
                var response = _mobileDataNetworkDataNetworksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataNetworkName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MobileDataNetworkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all data networks in the mobile network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/mobileNetworks/{mobileNetworkName}/dataNetworks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataNetworks_ListByMobileNetwork</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MobileDataNetworkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MobileDataNetworkResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _mobileDataNetworkDataNetworksRestClient.CreateListByMobileNetworkRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _mobileDataNetworkDataNetworksRestClient.CreateListByMobileNetworkNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new MobileDataNetworkResource(Client, MobileDataNetworkData.DeserializeMobileDataNetworkData(e)), _mobileDataNetworkDataNetworksClientDiagnostics, Pipeline, "MobileDataNetworkCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all data networks in the mobile network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/mobileNetworks/{mobileNetworkName}/dataNetworks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataNetworks_ListByMobileNetwork</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MobileDataNetworkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MobileDataNetworkResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _mobileDataNetworkDataNetworksRestClient.CreateListByMobileNetworkRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _mobileDataNetworkDataNetworksRestClient.CreateListByMobileNetworkNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new MobileDataNetworkResource(Client, MobileDataNetworkData.DeserializeMobileDataNetworkData(e)), _mobileDataNetworkDataNetworksClientDiagnostics, Pipeline, "MobileDataNetworkCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/mobileNetworks/{mobileNetworkName}/dataNetworks/{dataNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataNetworks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dataNetworkName"> The name of the data network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataNetworkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataNetworkName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string dataNetworkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataNetworkName, nameof(dataNetworkName));

            using var scope = _mobileDataNetworkDataNetworksClientDiagnostics.CreateScope("MobileDataNetworkCollection.Exists");
            scope.Start();
            try
            {
                var response = await _mobileDataNetworkDataNetworksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataNetworkName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/mobileNetworks/{mobileNetworkName}/dataNetworks/{dataNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataNetworks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dataNetworkName"> The name of the data network. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataNetworkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataNetworkName"/> is null. </exception>
        public virtual Response<bool> Exists(string dataNetworkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataNetworkName, nameof(dataNetworkName));

            using var scope = _mobileDataNetworkDataNetworksClientDiagnostics.CreateScope("MobileDataNetworkCollection.Exists");
            scope.Start();
            try
            {
                var response = _mobileDataNetworkDataNetworksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dataNetworkName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MobileDataNetworkResource> IEnumerable<MobileDataNetworkResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MobileDataNetworkResource> IAsyncEnumerable<MobileDataNetworkResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
