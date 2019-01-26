﻿using System;
namespace Meadow.Hardware
{
    /// <summary>
    /// Digital port.
    /// </summary>
    public interface IDigitalPort : IPort
    {
        IDigitalChannelInfo ChannelInfo { get; }

        /// <summary>
        /// Gets or sets the port state, either high (true), or low (false).
        /// </summary>
        bool State { get; }
    }
}