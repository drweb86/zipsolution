using System;
using System.Collections.Generic;
using System.Linq;
using SevenZip;

namespace ZipSolution.Core.Misc
{
    /// <summary>
    /// Archive method.
    /// </summary>
    sealed class ArchiveMethod
    {
        public CompressionMethod CompressionMethod { get;set; }

        public List<CompressionLevel> CompressionLevels { get; set; }

        public CompressionLevel CompressionLevelGoodDefault { get; private set; }

        public ArchiveMethod(CompressionMethod method,
            CompressionLevel levelGoodDefault,
            params CompressionLevel[] levels)
        {
            CompressionMethod = method;
            CompressionLevelGoodDefault = levelGoodDefault;
            CompressionLevels = levels.ToList();
        }
    }

    /// <summary>
    /// Supported archives.
    /// </summary>
    sealed class ArchiveProperties
    {
        #region Properties

        public string ArchiveExtension { get; private set; }
        public Dictionary<CompressionMethod, ArchiveMethod> Methods { get; private set; }

        public CompressionMethod CompressionMethodGoodDefault { get; private set;}

        #endregion

        #region Constructors

        public ArchiveProperties(
            string archiveExtension,
            CompressionMethod compressionMethodGoodDefault,
            params ArchiveMethod[] methods)
        {
            ArchiveExtension = archiveExtension;
            Methods = methods.ToDictionary(method => method.CompressionMethod, method => method);
            CompressionMethodGoodDefault = compressionMethodGoodDefault;
        }

        #endregion
    }

    /// <summary>
    /// Helps to operate with settings of compression.
    /// </summary>
    public static class CompressionHelper
    {
        #region Fields

        static readonly Dictionary<OutArchiveFormat, ArchiveProperties> _supportedArchives;

        #endregion

        #region Constructors

        static CompressionHelper()
        {
            _supportedArchives = new Dictionary<OutArchiveFormat, ArchiveProperties>();

            Add(OutArchiveFormat.SevenZip,
                "7z",
                CompressionMethod.Default,
                new ArchiveMethod(
                    CompressionMethod.Copy, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate64, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.BZip2, 
                    CompressionLevel.High, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma2, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Ppmd, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Default, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ));
            Add(OutArchiveFormat.Zip,
                "zip",
                CompressionMethod.Default,
                new ArchiveMethod(
                    CompressionMethod.Copy, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate64, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.BZip2, 
                    CompressionLevel.High, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Ppmd, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Default, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ));
            Add(OutArchiveFormat.GZip,
                "gz",
                CompressionMethod.Default,
                new ArchiveMethod(
                    CompressionMethod.Copy, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate64, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.BZip2, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma2, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Ppmd, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Default, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ));
            Add(OutArchiveFormat.BZip2,
                "bz2",
                CompressionMethod.Default,
                new ArchiveMethod(
                    CompressionMethod.Copy, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate64, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma2, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Ppmd, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Default, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ));
            Add(OutArchiveFormat.Tar,
                "tar",
                CompressionMethod.Default,
                new ArchiveMethod(
                    CompressionMethod.Copy, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate64, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.BZip2, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma2, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Ppmd, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Default, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ));
            Add(OutArchiveFormat.XZ,
                "xz",
                CompressionMethod.Default,
                new ArchiveMethod(
                    CompressionMethod.Copy, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Deflate64, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.BZip2, 
                    CompressionLevel.High, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Lzma2, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Ppmd, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ),
                new ArchiveMethod(
                    CompressionMethod.Default, 
                    CompressionLevel.High, 
                    CompressionLevel.None, 
                    CompressionLevel.Fast, 
                    CompressionLevel.Low, 
                    CompressionLevel.Normal, 
                    CompressionLevel.High, 
                    CompressionLevel.Ultra 
                   ));
        }

        #endregion

        #region Public Methods

        public static OutArchiveFormat[] GetAllowedOutArchiveFormats()
        {
            return _supportedArchives.Keys.ToArray();
        }

        public static bool IsSupportedOutArchiveFormat(OutArchiveFormat archiveFormat)
        {
            return _supportedArchives.ContainsKey(archiveFormat);
        }

        public static bool IsAllowedCompressionMethod (OutArchiveFormat archiveFormat, CompressionMethod method)
        {
            if (!IsSupportedOutArchiveFormat(archiveFormat))
            {
                return false;
            }

            return _supportedArchives[archiveFormat].Methods.ContainsKey(method);
        }

        public static bool IsAllowedCompressionLevel(OutArchiveFormat archiveFormat, 
            CompressionMethod method,
            CompressionLevel level)
        {
            if (!IsSupportedOutArchiveFormat(archiveFormat))
            {
                return false;
            }

            if (!IsAllowedCompressionMethod(archiveFormat, method))
            {
                return false;
            }

            return _supportedArchives[archiveFormat].Methods[method].CompressionLevels.Contains(level);
        }

        public static CompressionMethod[] GetAllowedCompressionMethods(OutArchiveFormat archiveFormat)
        {
            if (!IsSupportedOutArchiveFormat(archiveFormat))
            {
                return null;
            }

            return _supportedArchives[archiveFormat].Methods
                .Select(m=>m.Key)
                .ToArray();
        }

        public static CompressionLevel[] GetAllowedCompressionLevels(
            OutArchiveFormat archiveFormat,
            CompressionMethod method)
        {
            if (!IsSupportedOutArchiveFormat(archiveFormat))
            {
                return null;
            }

            if (!IsAllowedCompressionMethod(archiveFormat, method))
            {
                return null;
            }

            return _supportedArchives[archiveFormat].Methods[method].CompressionLevels.ToArray();
        }

        public static CompressionLevel GetCompressionLevelGoodDefault(
            OutArchiveFormat archiveFormat,
            CompressionMethod method)
        {
            if (!IsSupportedOutArchiveFormat(archiveFormat))
            {
                throw new NotSupportedException(archiveFormat.ToString());
            }

            if (!IsAllowedCompressionMethod(archiveFormat, method))
            {
                throw new NotSupportedException(string.Format("{0}-{1}",
                    archiveFormat,
                    method));
            }

            return _supportedArchives[archiveFormat].Methods[method].CompressionLevelGoodDefault;
        }

        public static CompressionMethod GetCompressionMethodGoodDefault(OutArchiveFormat archiveFormat)
        {
            if (!IsSupportedOutArchiveFormat(archiveFormat))
            {
                throw new NotSupportedException(archiveFormat.ToString());
            }

            return _supportedArchives[archiveFormat].CompressionMethodGoodDefault;
        }

        public static string GetArchiveExtension(OutArchiveFormat format)
        {
            if (!IsSupportedOutArchiveFormat(format))
            {
                return null;
            }

            return _supportedArchives[format].ArchiveExtension;
        }

        #endregion

        #region Private Methods

        private static void Add(OutArchiveFormat format,
            string archiveExtension,
            CompressionMethod goodDefaultCompressionMethod,
            params ArchiveMethod[] methods)
        {
            _supportedArchives.Add(format, new ArchiveProperties(archiveExtension, goodDefaultCompressionMethod, methods));
        }

        #endregion
    }
}
