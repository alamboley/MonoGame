// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.IO;

using Google.Android.Vending.Expansion.ZipFile;

namespace Microsoft.Xna.Framework
{
    partial class TitleContainer
    {
        static ZipResourceFile expansionFiles;

        private static Stream PlatformOpenStream(string safeName)
        {
            try
            {
                return Android.App.Application.Context.Assets.Open(safeName);
            }
            catch (Exception)
            {
                if (expansionFiles == null)
                    expansionFiles = APKExpansionSupport.GetAPKExpansionZipFile(Game.Activity.ApplicationContext, Game.Activity.ApplicationContext.PackageManager.GetPackageInfo(Game.Activity.ApplicationContext.PackageName, 0).VersionCode, 0);
                
                return expansionFiles.GetInputStream(safeName);
            }
        }
    }
}

