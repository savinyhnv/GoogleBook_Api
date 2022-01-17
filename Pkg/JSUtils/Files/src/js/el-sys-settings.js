define("el-sys-settings", [], () => {
  Ext.define("EdenLab.SysSettings", {
    override: "Terrasoft.SysSettings",

    async querySysSettingAsync(sysSetting) {
      return new Promise(resolve => this.querySysSetting(
        [sysSetting], result => resolve(result), this, null, true));
    },

    async querySysSettingsAsync(sysSettingsNameArray) {
      return new Promise(resolve => this.querySysSetting(
        sysSettingsNameArray, result => resolve(result), this, null, false));
    }
  });
});
