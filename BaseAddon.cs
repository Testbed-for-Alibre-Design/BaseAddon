using System;
using System.Collections.Generic;
using System.Diagnostics;
using AlibreAddOn;
using AlibreX;
using System.Windows.Forms;
namespace BaseAddon
{
    public class BaseAddon : IAlibreAddOn
    {
        private const int MenuIdRoot = 401;
        private const int MenuIdUtils = 601;
        private int[] _menuIdsRoot;
        private IADRoot _alibreRoot;
        private readonly IntPtr _parentWinHandle;
        public BaseAddon(IADRoot alibreRoot, IntPtr parentWinHandle)
        {
            _alibreRoot = alibreRoot;
            _parentWinHandle = parentWinHandle;
            BuildMenuTree();
        }
        public int RootMenuItem => MenuIdRoot;
        private void BuildMenuTree()
        {
            _menuIdsRoot = new int[1]
            {
               MenuIdUtils
            };
        }
        public bool HasSubMenus(int menuId)
        {
            switch (menuId)
            {
                case MenuIdRoot: return true;
            }
            return false;
        }
        public Array SubMenuItems(int menuId)
        {
            switch (menuId)
            {
                case MenuIdRoot: return _menuIdsRoot;
            }
            return null;
        }
        public string MenuItemText(int menuId)
        {
            switch (menuId)
            {
                case MenuIdRoot: return "Base Addon";
            }
            return "";
        }
        public bool PopupMenu(int menuId)
        {
            return false;
        }
        public ADDONMenuStates MenuItemState(int menuId, string sessionIdentifier)
        {
            var session = _alibreRoot.Sessions.Item(sessionIdentifier);
            switch (session)
            {
                case IADDrawingSession:
                    switch (menuId)
                    {
                       case MenuIdRoot: return ADDONMenuStates.ADDON_MENU_ENABLED;
                    }
                    break;
                case IADAssemblySession:
                    switch (menuId)
                    {
                        case MenuIdRoot: return ADDONMenuStates.ADDON_MENU_ENABLED;
                    }
                    break;
                case IADPartSession:
                    switch (menuId)
                    {
                       case MenuIdRoot: return ADDONMenuStates.ADDON_MENU_ENABLED;
                    }
                    break;
            }
            return ADDONMenuStates.ADDON_MENU_ENABLED;
        }
        public string MenuItemToolTip(int menuId)
        {
            switch (menuId)
            {
                case MenuIdUtils: return "BaseAddon";
            }
            return "";
        }
        public string MenuIcon(int menuId)
        {
             switch (menuId)
             {
               case MenuIdUtils: return "logo.ico";
             }
            return string.Empty;
        }
        public bool HasPersistentDataToSave(string sessionIdentifier)
        {
            return false;
        }
        public IAlibreAddOnCommand InvokeCommand(int menuId, string sessionIdentifier)
        {
            var session = _alibreRoot.Sessions.Item(sessionIdentifier);
            switch (menuId)
            {
                case MenuIdUtils:
                {
                    return BaseAddonCmd(session);
                }
            }
            return null;
        }
        private IAlibreAddOnCommand BaseAddonCmd(IADSession currentSession)
        {
            MessageBox.Show("BaseAddon", "BaseAddonCommand", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }
        public void SaveData(IStream pCustomData, string sessionIdentifier)
        {
        }
        public void setIsAddOnLicensed(bool isLicensed)
        {
        }
        public bool UseDedicatedRibbonTab()
        {
            return false;
        }
        public void LoadData(IStream pCustomData, string sessionIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}