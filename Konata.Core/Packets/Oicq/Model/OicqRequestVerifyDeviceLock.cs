﻿using Konata.Core.Common;
using Konata.Core.Packets.Tlv;
using Konata.Core.Packets.Tlv.Model;

namespace Konata.Core.Packets.Oicq.Model;

using Tlv = Tlv.Tlv;

internal class OicqRequestVerifyDeviceLock : OicqRequest
{
    private const ushort OicqCommand = 0x0810;
    private const ushort OicqSubCommand = 0x0014;

    public OicqRequestVerifyDeviceLock(BotKeyStore signinfo)
        : base(OicqCommand, signinfo.Account.Uin, signinfo.Ecdh.MethodId,
            signinfo.KeyStub.RandKey, signinfo.Ecdh, w =>
            {
                var tlvs = new TlvPacker();
                {
                    tlvs.PutTlv(new Tlv(0x0008, new T8Body(2052)));
                    tlvs.PutTlv(new Tlv(0x0104, new T104Body(signinfo.Session.WtLoginSession)));
                    tlvs.PutTlv(new Tlv(0x0116, new T116Body(AppInfo.WtLoginSdk.MiscBitmap,
                        AppInfo.WtLoginSdk.SubSigBitmap, AppInfo.WtLoginSdk.SubAppIdList)));
                    tlvs.PutTlv(new Tlv(0x401, new T401Body(signinfo.Session.GSecret))); // G
                }

                w.PutUshortBE(OicqSubCommand);
                w.PutBytes(tlvs.GetBytes(true));
            })
    {
    }
}
