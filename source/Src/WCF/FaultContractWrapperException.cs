﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF
{
    /// <summary>
    /// Class that wraps a FaultContract exception.
    /// </summary>
    [Serializable]
    public class FaultContractWrapperException : Exception
    {
        [NonSerialized]
        private object faultContract;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FaultContractWrapperException"/> class.
        /// </summary>
        /// <param name="faultContract">The fault contract.</param>
        public FaultContractWrapperException(object faultContract)
            : this(faultContract, Guid.NewGuid(), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FaultContractWrapperException"/> class.
        /// </summary>
        /// <param name="faultContract">The fault contract.</param>
        /// <param name="handlingInstanceId">The handling instance id.</param>
        public FaultContractWrapperException(object faultContract, Guid handlingInstanceId)
            : this(faultContract, handlingInstanceId, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FaultContractWrapperException"/> class.
        /// </summary>
        /// <param name="faultContract">The fault contract.</param>
        /// <param name="handlingInstanceId">The handling instance id.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        public FaultContractWrapperException(object faultContract, Guid handlingInstanceId, string exceptionMessage)
            : base(exceptionMessage ?? ExceptionUtility.FormatExceptionMessage(null, handlingInstanceId))
        {
            if (faultContract == null)
            {
                throw new ArgumentNullException("faultContract");
            }
            this.faultContract = faultContract;
        }

        /// <summary>
        /// Gets or sets the fault contract.
        /// </summary>
        /// <value>The fault contract.</value>
        public object FaultContract
        {
            get { return faultContract; }
            set { faultContract = value; }
        }
    }
}
