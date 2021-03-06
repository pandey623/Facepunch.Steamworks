﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facepunch.Steamworks.Test
{
    [TestClass]
    [DeploymentItem( "steam_api.dll" )]
    [DeploymentItem( "steam_api64.dll" )]
    [DeploymentItem( "steam_appid.txt" )]
    public class RichPresence
    {
        [TestMethod]
        public void MissingKeyIsNull()
        {
            using ( var client = new Steamworks.Client( 252490 ) )
            {
                var key = client.User.GetRichPresence( "Missing Key" );
                Assert.IsNull( key );
            }
        }

        [TestMethod]
        public void ReadBackSetKey()
        {
            using ( var client = new Steamworks.Client( 252490 ) )
            {
                client.User.SetRichPresence( "One", "Two" );

                var value = client.User.GetRichPresence( "One" );
                Assert.IsNotNull( value );
                Assert.AreEqual( value, "Two" );
            }
        }

        [TestMethod]
        public void ClearingKeys()
        {
            using ( var client = new Steamworks.Client( 252490 ) )
            {
                client.User.SetRichPresence( "One", "Two" );

                var value = client.User.GetRichPresence( "One" );
                Assert.IsNotNull( value );
                Assert.AreEqual( value, "Two" );

                client.User.ClearRichPresence();

                value = client.User.GetRichPresence( "One" );
                Assert.IsNull( value );
            }
        }
    }
}