using ExitGames.Client.Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationController : PhotonPeer
{
    protected internal static Type PingImplementation = null;

    private readonly Dictionary<byte, object> opParameters = new Dictionary<byte, object>(); // used in OpRaiseEvent() (avoids lots of new Dictionary() calls)


    /// <summary>
    /// Creates a Peer with specified connection protocol. You need to set the Listener before using the peer.
    /// </summary>
    /// <remarks>Each connection protocol has it's own default networking ports for Photon.</remarks>
    /// <param name="protocolType">The preferred option is UDP.</param>
    public OperationController(ConnectionProtocol protocolType) : base(protocolType)
    {
        // this does not require a Listener, so:
        // make sure to set this.Listener before using a peer!
    }

    /// <summary>
    /// Creates a Peer with specified connection protocol and a Listener for callbacks.
    /// </summary>
    public OperationController(IPhotonPeerListener listener, ConnectionProtocol protocolType) : this(protocolType)
    {
        this.Listener = listener;
    }

 
}
