using System;
namespace Proyecto_AppMoviles_.AppConstant
{
    public class Constants
    {
		public static string AppName = "OAuthNativeFlow";

		// OAuth
		// For Google login, configure at https://console.developers.google.com/
		public static string iOSClientId = "541807455263-n92bashs3n9v1a6lv42tp32o8qo9ug9c.apps.googleusercontent.com";
		public static string AndroidClientId = "541807455263-q5nts7nktbku7rqe4m3a94qjb8b39p4t.apps.googleusercontent.com";

		// These values do not need changing
		public static string Scope = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";
		public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
		public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
		public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

		// Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
		public static string iOSRedirectUrl = "com.googleusercontent.apps.541807455263-n92bashs3n9v1a6lv42tp32o8qo9ug9c:/oauth2redirect";
		public static string AndroidRedirectUrl = "com.googleusercontent.apps.541807455263-q5nts7nktbku7rqe4m3a94qjb8b39p4t:/oauth2redirect";
	}
}
