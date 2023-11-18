using AlibreAddOn;
using AlibreX;
using System;
namespace AlibreAddOnAssembly
{
    public static class AlibreAddOn
    {
        private static IADRoot AlibreRoot { get; set; }
        private static IntPtr _parentWinHandle;
        private static BaseAddon.BaseAddon _basesAddonHandle;
        private static LauncherAddon.LauncherAddon _laucherAddonHandle;
        public static void AddOnLoad(IntPtr hwnd, IAutomationHook pAutomationHook, IntPtr unused)
        {
            AlibreRoot = (IADRoot) pAutomationHook.Root;
            _parentWinHandle = hwnd;
            _basesAddonHandle = new BaseAddon.BaseAddon(AlibreRoot, _parentWinHandle);
            _laucherAddonHandle = new LauncherAddon.LauncherAddon(AlibreRoot, _parentWinHandle);
        }
        public static IADRoot GetRoot()
        {
            return AlibreRoot;
        }
        public static void AddOnInvoke(
            IntPtr hwnd,
            IntPtr pAutomationHook,
            string sessionName,
            bool isLicensed,
            int reserved1,
            int reserved2)
        {
        }
        public static void AddOnUnload(
            IntPtr hwnd,
            bool forceUnload,
            ref bool cancel,
            int reserved1,
            int reserved2)
        {
        }
        public static IAlibreAddOn GetAddOnInterface()
        {
            return (IAlibreAddOn)_laucherAddonHandle;
        }
    }
}