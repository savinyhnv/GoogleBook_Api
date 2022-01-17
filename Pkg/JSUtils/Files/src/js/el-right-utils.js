define("el-right-utils", ["RightUtilities"], () => {
  Ext.define("EdenLab.RightUtilities", {
    extend: "Terrasoft.configuration.RightUtilities",

    async checkCanExecuteOperationAsync(data) {
      return new Promise(
        resolve => this.checkCanExecuteOperation(data, response => resolve(response), this));
    },

    /**
     * Returns array of roles by contact
     * @returns {Promise<Array>}
     */
    async getRolesByContact(contactId) {
      let select = Ext.create("Terrasoft.EntitySchemaQuery", {
        rootSchemaName: "SysUserInRole",
      });
      select.addColumn("SysRole");
      select.filters.add("UserContact", Terrasoft.createColumnFilterWithParameter(
        Terrasoft.ComparisonType.EQUAL, "SysUser.Contact", contactId));
      return new Promise(resolve => select.execute(
        response => resolve(response.collection.collection.items.map(e => e.$SysRole.value)), this));
    },

    /**
     * Returns empty string if record can be edited or error message otherwise
     * @param {Object} data
     * @param {string} data.schemaName
     * @param {string} data.primaryColumnValue
     * @param {boolean} data.isNew
     * @returns {Promise<string>}
     */
    async checkCanEditAsync(data) {
      return new Promise(resolve => this.checkCanEdit(data, response => resolve(response), this));
    },

    async getSchemaOperationRightLevelAsync(schemaName) {
      return new Promise(
        resolve => this.getSchemaOperationRightLevel(schemaName, response => resolve(response), this));
    }
  });

  EdenLab.RightUtilities = Ext.create("EdenLab.RightUtilities");

  return EdenLab.RightUtilities;
});
