﻿using Syfuhs.Security.Kerberos.Entities.Authorization;
using System;
using System.Text;

namespace Syfuhs.Security.Kerberos.Entities
{
    public class PacClientInfo
    {
        public PacClientInfo(byte[] data)
        {
            var pacStream = new NdrBinaryReader(data);

            ClientId = pacStream.ReadFiletime();
            NameLength = pacStream.ReadShort();
            Name = Encoding.Unicode.GetString(pacStream.Read(NameLength));
        }

        public DateTimeOffset ClientId { get; private set; }

        public short NameLength { get; private set; }

        public string Name { get; private set; }
    }
}