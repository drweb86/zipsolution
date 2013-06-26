using System;
using System.IO;
using System.Linq;

namespace ZipSolution.Core.Commands.Hg
{
    static class HgHelper
    {
        public static string FindHg()
        {
            return (Environment
                .GetEnvironmentVariable("PATH") ?? string.Empty)
                .Split(';')
                .Select(item => Path.Combine(item, "hg.exe"))
                .Where(File.Exists)
                .FirstOrDefault();
        }

        public static HgInfo GetHgInfo(string hg, string folder)
        {
            if (hg == null)
            {
                throw new ArgumentNullException("HG is not available.", "hg");
            }

            string stdOutput;
            int exitCode;
            string stdError;

            string branch = "Unknown";

            ExecuteProcessHelper.ExecuteAndGrabOutputNotLoadProfile(
                hg,
                folder,
                "branch",

                out stdOutput,
                out exitCode,
                out stdError);

            if (exitCode == 0)
            {
                branch = stdOutput
                    .Trim('\r')
                    .Trim('\n')
                    .Trim('\r');
            }
            else
            {
                throw new ApplicationException(string.Format("Cannot get hg branch: {0}. {1}.", stdOutput, stdError));
            }

            string nodeFull = "Unknown";

            ExecuteProcessHelper.ExecuteAndGrabOutputNotLoadProfile(
                hg,
                folder,
                "--debug id -i",

                out stdOutput,
                out exitCode,
                out stdError);

            if (exitCode == 0)
            {
                nodeFull = stdOutput
                    .Trim('\r')
                    .Trim('\n')
                    .Trim('\r')
                    .Trim('+');
            }
            else
            {
                throw new ApplicationException(string.Format("Cannot get hg full node name: {0}. {1}.", stdOutput, stdError));
            }

            string nodeShort = "Unknown";

            ExecuteProcessHelper.ExecuteAndGrabOutputNotLoadProfile(
                hg,
                folder,
                "id -i",

                out stdOutput,
                out exitCode,
                out stdError);

            if (exitCode == 0)
            {
                nodeShort = stdOutput
                    .Trim('\r')
                    .Trim('\n')
                    .Trim('\r')
                    .Trim('+');
            }
            else
            {
                throw new ApplicationException(string.Format("Cannot get hg short node name: {0}. {1}.", stdOutput, stdError));
            }

            string revision = "Unknown";

            ExecuteProcessHelper.ExecuteAndGrabOutputNotLoadProfile(
                hg,
                folder,
                "id -n",

                out stdOutput,
                out exitCode,
                out stdError);

            if (exitCode == 0)
            {
                revision = stdOutput
                    .Trim('\r')
                    .Trim('\n')
                    .Trim('\r')
                    .Trim('+');
            }
            else
            {
                throw new ApplicationException(string.Format("Cannot get hg revision: {0}. {1}.", stdOutput, stdError));
            }

            return new HgInfo(branch, revision, nodeShort, nodeFull);
        }


    }
}
