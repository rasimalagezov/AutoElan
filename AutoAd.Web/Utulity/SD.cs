﻿namespace AutoAd.Web.Utulity
{
    public class SD
    {
        public static string AutoAdAPIBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleUser = "USER";
        public const string TokenCookie = "JwtToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public enum ContentType
        {
            Json,
            MultipartFormData
        }
    }
}
