﻿using System.Reflection;

namespace Cropper.Blazor.Client.Models
{
    // this is needed for the copy-to-clipboard feature
    public static partial class Snippets
    {
        public static string GetCode(string component)
        {
            var field = typeof(Snippets).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField)
                .FirstOrDefault(f => f.Name == component);
            if (field == null)
                return $"Snippet for component '{component}' not found!";
            return (string)field.GetValue(null);

        }

        public const string InstallScriptManual = @"<script src=""_content/Cropper.Blazor/cropper.min.js""></script>";
    }
}