using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Unicoen.Utils {
	public static class Downloader {
		public static void Download(string url, string outPath) {
			using (var client = new WebClient())
			using (var stream = client.OpenRead(url))
			using (var file = new FileStream(outPath, FileMode.Create)) {
				var buff = new byte[64 * 1024];
				int len;
				while((len = stream.Read(buff, 0, buff.Length)) > 0) {
					file.Write(buff, 0, len);
				}
			}
		}

		public static Stream GetStream(string url) {
			return new WebClient().OpenRead(url);
		}
	}
}
