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

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a collection of <see cref="SubscriptionResource" /> and their operations.
    /// Each <see cref="SubscriptionResource" /> in the collection will belong to the same instance of <see cref="TenantResource" />.
    /// To get a <see cref="SubscriptionCollection" /> instance call the GetSubscriptions method from an instance of <see cref="TenantResource" />.
    /// </summary>
    public partial class SubscriptionCollection : ArmCollection, IEnumerable<SubscriptionResource>, IAsyncEnumerable<SubscriptionResource>
    {
        private readonly ClientDiagnostics _subscriptionClientDiagnostics;
        private readonly SubscriptionsRestOperations _subscriptionRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionCollection"/> class for mocking. </summary>
        protected SubscriptionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SubscriptionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subscriptionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", SubscriptionResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SubscriptionResource.ResourceType, out string subscriptionApiVersion);
            _subscriptionRestClient = new SubscriptionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, subscriptionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets details about a specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual async Task<Response<SubscriptionResource>> GetAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var scope = _subscriptionClientDiagnostics.CreateScope("SubscriptionCollection.Get");
            scope.Start();
            try
            {
                var response = await _subscriptionRestClient.GetAsync(subscriptionId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubscriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets details about a specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual Response<SubscriptionResource> Get(string subscriptionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var scope = _subscriptionClientDiagnostics.CreateScope("SubscriptionCollection.Get");
            scope.Start();
            try
            {
                var response = _subscriptionRestClient.Get(subscriptionId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubscriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all subscriptions for a tenant.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubscriptionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _subscriptionRestClient.CreateListRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _subscriptionRestClient.CreateListNextPageRequest(nextLink);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubscriptionResource(Client, SubscriptionData.DeserializeSubscriptionData(e)), _subscriptionClientDiagnostics, Pipeline, "SubscriptionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all subscriptions for a tenant.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubscriptionResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _subscriptionRestClient.CreateListRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _subscriptionRestClient.CreateListNextPageRequest(nextLink);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubscriptionResource(Client, SubscriptionData.DeserializeSubscriptionData(e)), _subscriptionClientDiagnostics, Pipeline, "SubscriptionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var scope = _subscriptionClientDiagnostics.CreateScope("SubscriptionCollection.Exists");
            scope.Start();
            try
            {
                var response = await _subscriptionRestClient.GetAsync(subscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual Response<bool> Exists(string subscriptionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var scope = _subscriptionClientDiagnostics.CreateScope("SubscriptionCollection.Exists");
            scope.Start();
            try
            {
                var response = _subscriptionRestClient.Get(subscriptionId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SubscriptionResource> IEnumerable<SubscriptionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SubscriptionResource> IAsyncEnumerable<SubscriptionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
