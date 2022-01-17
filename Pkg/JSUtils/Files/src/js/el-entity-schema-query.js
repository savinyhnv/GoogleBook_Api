define("el-entity-schema-query", [], () => {
  Ext.define("EdenLab.EntitySchemaQuery", {
    override: "Terrasoft.EntitySchemaQuery",

    async queryAsync() {
      return new Promise(resolve => this.execute(response => resolve(response), this));
    },

    async queryFirstAsync() {
      const result = await this.queryAsync();
      return result.collection?.first();
    },

    async queryCountAsync() {
      const result = await this.queryAsync();
      return result.collection?.getCount() ?? 0;
    }
  });
})
