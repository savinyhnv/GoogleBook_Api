define("el-filter-group", [], () => {
  Ext.define("EdenLab.FilterGroup", {
    override: "Terrasoft.FilterGroup",

    addEqualsFilter(leftExpression, rightExpression, alias) {
      let filter = Terrasoft.createColumnFilterWithParameter(
        Terrasoft.ComparisonType.EQUAL, leftExpression, rightExpression);
      this._addFilterItem(filter, alias);
    },

    addNotEqualsFilter(leftExpression, rightExpression, alias) {
      let filter = Terrasoft.createColumnFilterWithParameter(
        Terrasoft.ComparisonType.NOT_EQUAL, leftExpression, rightExpression);
      this._addFilterItem(filter, alias);
    },

    addInFilter(columnPath, parameterValues, alias) {
      let filter = Terrasoft.createColumnInFilterWithParameters(columnPath, parameterValues);
      this._addFilterItem(filter, alias);
    },

    addNotInFilter(columnPath, parameterValues, alias) {
      let filter = Terrasoft.createColumnInFilterWithParameters(columnPath, parameterValues);
      filter.comparisonType = Terrasoft.ComparisonType.NOT_EQUAL;
      this._addFilterItem(filter, alias);
    },

    addExistsFilter(columnPath, alias) {
      let filter = Terrasoft.createExistsFilter(columnPath);
      this._addFilterItem(filter, alias);
      return filter;
    },

    addNotExistsFilter(columnPath, alias) {
      let filter = Terrasoft.createNotExistsFilter(columnPath);
      this._addFilterItem(filter, alias);
      return filter;
    },

    _addFilterItem(filter, alias) {
      if (!!alias) {
        this.add(alias, filter);
      } else {
        this.addItem(filter);
      }
    }
  });
});
