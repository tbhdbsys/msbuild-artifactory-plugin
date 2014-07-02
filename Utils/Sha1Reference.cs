﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JFrog.Artifactory.Utils
{
    /// <summary>
    /// generate a SHA1 to a given file
    /// </summary>
    public class Sha1Reference
    {

        /// <summary>
        /// generate the SHA1 for a file 
        /// </summary>
        /// <param name="path">the path for the file and its name</param>
        /// <returns>SHA1 as string</returns>
        public string GenerateSHA1(string path)
        {
            if (path == null) return string.Empty;
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var sha1 = new SHA1Managed())
                {
                    return BitConverter.ToString(sha1.ComputeHash(fs)).Replace("-", "").ToLower();
                }
            }
        }
    }
}
