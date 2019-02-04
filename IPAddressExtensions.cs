// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPAddressExtensions.cs" company="Solid Optics">
//   
// Copyright 2017 Solid Optics. </copyright>
// <author>Ronald Philipsen</author>
// <summary>
//   The internet protocol address extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RPhil.Utils
{
    using System;
    using System.Net;

    /// <summary> The internet protocol address extensions. </summary>
    public static class IpAddressExtensions
    {
        /// <summary>gets the broadcast address for a given subnet </summary>
        /// <param name="address">The address. </param>
        /// <param name="subnetMask">The subnet mask. </param>
        /// <returns>The broadcast <see cref="IPAddress"/>. </returns>
        /// <exception cref="ArgumentException">on illegal arguments </exception>
        public static IPAddress GetBroadcastAddress(this IPAddress address, IPAddress subnetMask)
        {
            var ipAddressBytes = address.GetAddressBytes();
            var subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAddressBytes.Length != subnetMaskBytes.Length)
            {
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
            }

            var broadcastAddress = new byte[ipAddressBytes.Length];
            for (var i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAddressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }

            return new IPAddress(broadcastAddress);
        }

        /// <summary>Checks whether two addresses exist in the same subnet. </summary>
        /// <param name="address2">The address 2. </param>
        /// <param name="address">The address. </param>
        /// <param name="subnetMask">The subnet mask. </param>
        /// <returns>The <see cref="bool"/>. </returns>
        public static bool IsInSameSubnet(this IPAddress address2, IPAddress address, IPAddress subnetMask)
        {
            var network1 = address.GetNetworkAddress(subnetMask);
            var network2 = address2.GetNetworkAddress(subnetMask);

            return network1.Equals(network2);
        }

        /// <summary>gets the network address. </summary>
        /// <param name="address">The address. </param>
        /// <param name="subnetMask">The subnet mask. </param>
        /// <returns>The <see cref="IPAddress"/>. </returns>
        /// <exception cref="ArgumentException">on illegal args </exception>
        private static IPAddress GetNetworkAddress(this IPAddress address, IPAddress subnetMask)
        {
            var ipAddressBytes = address.GetAddressBytes();
            var subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAddressBytes.Length != subnetMaskBytes.Length)
            {
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
            }

            var broadcastAddress = new byte[ipAddressBytes.Length];
            for (var i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAddressBytes[i] & subnetMaskBytes[i]);
            }

            return new IPAddress(broadcastAddress);
        }
    }
}