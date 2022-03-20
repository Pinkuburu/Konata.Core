﻿using System.Collections.Generic;
using Konata.Core.Events.Model;
using Konata.Core.Utils.Extensions;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CollectionNeverQueried.Global
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace Konata.Core.Message.Model;

public class MultiMsgChain : XmlChain
{
    /// <summary>
    /// Messages
    /// </summary>
    internal List<MessageStruct> Messages { get; }

    /// <summary>
    /// Multimsg up information
    /// </summary>
    internal MultiMsgUpInfo MultiMsgUpInfo { get; private set; }

    /// <summary>
    /// Packed data
    /// </summary>
    internal byte[] PackedData { get; private set; }

    /// <summary>
    /// Guid
    /// </summary>
    internal string Guid { get; private set; }

    private MultiMsgChain() : base("")
    {
        Messages = new();
        Type = ChainType.MultiMsg;
    }

    /// <summary>
    /// Add message
    /// </summary>
    /// <param name="reference"></param>
    /// <returns></returns>
    public MultiMsgChain AddMessage(MessageStruct reference)
    {
        Messages.Add(reference);
        return this;
    }

    /// <summary>
    /// Set upload info
    /// </summary>
    /// <param name="info"></param>
    /// <param name="packed"></param>
    internal void SetMultiMsgUpInfo(MultiMsgUpInfo info, byte[] packed)
    {
        MultiMsgUpInfo = info;
        PackedData = packed;
    }

    internal void SetGuid(byte[] guid)
        => Guid = guid.ToHex();

    /// <summary>
    /// Create mulimsg chain
    /// </summary>
    public static MultiMsgChain Create()
        => new();

    internal override string ToPreviewString()
        => "[聊天记录]";
}
