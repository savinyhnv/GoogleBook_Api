define("el-base-query", [], () => {
  Ext.define("EdenLab.BaseQuery", {
    override: "Terrasoft.BaseQuery",

    addColumns() {
      [...(arguments ?? [])]?.forEach(element => {
        this.addColumn(element);
      });
    },

    async executeAsync() {
      return new Promise(resolve => this.execute(response => resolve(response), this));
    }
  });
});
