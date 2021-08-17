﻿using System.Collections.Generic;

namespace Konata.Core
{
    public class BotGroup
    {
        /// <summary>
        /// Group uin
        /// </summary>
        public uint Uin { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Group owner uin
        /// </summary>
        public uint OwnerUin { get; set; }

        /// <summary>
        /// Group admins
        /// </summary>
        public List<uint> AdminUins { get; set; }

        /// <summary>
        /// Group member count
        /// </summary>
        public uint MemberCount { get; set; }

        /// <summary>
        /// Group max member count
        /// </summary>
        public uint MaxMemberCount { get; set; }

        /// <summary>
        /// Group muted
        /// </summary>
        public uint Muted { get; set; }

        /// <summary>
        /// Muted me
        /// </summary>
        public uint MutedMe { get; set; }

        /// <summary>
        /// Group members
        /// </summary>
        public Dictionary<uint, BotMember> Members { get; set; }

        public BotGroup()
        {
            Name = "";
            Members = new();
            AdminUins = new();
        }
    }
}
