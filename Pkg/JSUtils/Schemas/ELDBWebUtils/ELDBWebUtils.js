define(
	"ELDBWebUtils",
	[],
	function() {
		/**
		 * Get filter group of "EQUALS" or "IN" comparison type
		 * @param {Object} options
		 * @param {Terrasoft.LogicalOperatorType} [options.logicalOperation=Terrasoft.LogicalOperatorType.AND] -
		 * logical operation
		 * @param {Object.<string, *>|Object.<string, *[]>} options.filters - key:value object.
		 * Value as array is used for "IN" comparison type
		 * @param {boolean} [options.isNotEqual] - must be set to true if not equal comparison is needed
		 * @returns {Terrasoft.FilterGroup}
		 */
		function createEqualFilterGroup(options) {
			var comparisonType = options.isNotEqual ?
				Terrasoft.ComparisonType.NOT_EQUAL :
				Terrasoft.ComparisonType.EQUAL;
			var fGroup = Terrasoft.createFilterGroup();
			fGroup.logicalOperation = options.hasOwnProperty("logicalOperation") ?
				options.logicalOperation :
				Terrasoft.LogicalOperatorType.AND;
			Object.keys(options.filters).forEach(function(key) {
				var filter;
				if (Ext.isArray(options.filters[key])) {
					filter = Terrasoft.createColumnInFilterWithParameters(key, options.filters[key]);
					filter.comparisonType = comparisonType;
				} else {
					filter = Terrasoft.createColumnFilterWithParameter(comparisonType, key, options.filters[key]);
				}
				fGroup.add(key + "Filter", filter);
			});
			return fGroup;
		}
		
		/**
		 * Adds columns to esq if esq doesn't already contains them
		 * @param {Terrasoft.EntitySchemaQuery} esq - ESQ instance to add columns
		 * @param {Array.<string|Object.<string, string>>} columns - columns to add.
		 * Must be array with strings or key:value object items, where key is column name and value is column alias
		 */

		/**
		 * @param esq
		 * @param columns
		 */
		function addESQColumns(esq, columns) {
			columns.forEach(function(c) {
				var name, alias;
				if (Ext.isObject(c)) {
					name = Object.keys(c)[0];
					alias = c[Object.keys(c)[0]];
				} else {
					name = alias = c;
				}
				if (!esq.columns.contains(alias)) {
					esq.addColumn(name, alias);
				}
			});
		}
		
		/**
		 * Get configured by options ESQ
		 * @param {Object} options
		 * @param {string} options.tableName - db table name
		 * @param {Array.<string|Object.<string, string>>} options.columns - columns to add.
		 * Must be array of string or key:value object items, where key is column name and value is column alias
		 * @param {string} [options.sortColumnName] - name of column for order by
		 * @param {Terrasoft.OrderDirection} [options.sortDirection=Terrasoft.OrderDirection.ASC] - order by direction
		 * @param {Terrasoft.FilterGroup} [options.filterGroup] - query filters
		 * @returns {Terrasoft.EntitySchemaQuery}
		 */
		function createESQ(options) {
			var select = Ext.create("Terrasoft.EntitySchemaQuery", {rootSchemaName: options.tableName});
			addESQColumns(select, options.columns);
			if (options.sortColumnName) {
				var column = select.columns.find(options.sortColumnName);
				if (column) {
					column.orderDirection = options.sortDirection || Terrasoft.OrderDirection.ASC;
				}
			}
			if (options.filterGroup) {
				select.filters.addItem(options.filterGroup);
			}
			return select;
		}
		
		/**
		 * Create and execute esq to get items from db
		 * @param {Object} options
		 * @param {string} options.tableName - db table name
		 * @param {Array.<string|Object.<string, string>>} options.columns - columns to add.
		 * Must be array of string or key:value object items, where key is column name and value is column alias
		 * @param {Object} options.scope - scope for callback function
		 * @param {Function} options.callback - will be called with Terrasoft.BaseViewModel[] as first argument and
		 * and original collection as second
		 * @param {Terrasoft.FilterGroup} [options.filterGroup] - query filters
		 * @param {string} [options.sortColumnName] - name of column for order by
		 * @param {Terrasoft.OrderDirection} [options.sortDirection=Terrasoft.OrderDirection.ASC] - order by direction
		 */
		function getItemsFromDB(options) {
			createESQ(options).getEntityCollection(function(response) {
				options.callback.call(
					this,
					(response.success && response.collection.getItems()) || [],
					response.collection
				);
			}, options.scope);
		}

		/**
		 * Sets lookup value (object of {value, displayValue}) shape to ViewModel attribute by given filters
		 * @param {Object} options
		 * @param {string} options.tableName - db table name of Lookup value
		 * @param {Terrasoft.FilterGroup} options.filterGroup - filters to find record in db
		 * @param {string} options.viewModelColumnName - name of ViewModel lookup attribute
		 * @param {Terrasoft.BaseViewModel} options.viewModel - view model
		 * @param {Function} [options.callback] - function called after value is set
		 * @param {string} [options.displayColumnName=Name] - name of column, which value will be set to displayValue
		 * @param {string} [options.isSetLookupListConfigColumns=false] - set additional columns from lookupListConfig
		 */
		function setLookupValueByFilterGroup(options) {
			var displayColumnName = options.displayColumnName || "Name";
			var additionalColumns = options.isSetLookupListConfigColumns ?
				(
					((options.viewModel.columns[options.viewModelColumnName] || {}).lookupListConfig || {}).columns
				) :
				[];
			getItemsFromDB({
				tableName: options.tableName,
				columns: [
					"Id",
					displayColumnName
				].concat(additionalColumns || []),
				filterGroup: options.filterGroup,
				callback: function(items) {
					if (items.length) {
						var entity = items[0];
						var value = {
							value: entity.get("Id"),
							displayValue: entity.get(displayColumnName)
						};
						additionalColumns.forEach(function(c) {
							value[c] = entity.get(c);
						});
						options.viewModel.set(options.viewModelColumnName, value);
					}
					if (options.callback) {
						options.callback.call(options.viewModel, items);
					}
				},
				scope: this
			});
		}

		/**
		 * Sets lookup value (object of {value, displayValue}) shape to ViewModel attribute by record id
		 * @param {Object} options
		 * @param {string} options.id - id of db record
		 * @param {string} options.tableName - db table name of Lookup value
		 * @param {string} options.viewModelColumnName - name of ViewModel lookup attribute
		 * @param {Terrasoft.BaseViewModel} options.viewModel - view model
		 * @param {Function} [options.callback] - function called after value is set
		 * @param {string} [options.displayColumnName=Name] - name of column, which value will be set to displayValue
		 * @param {string} [options.isSetLookupListConfigColumns=false] - set additional columns from lookupListConfig
		 */
		function setLookupValueById(options) {
			setLookupValueByFilterGroup(
				Ext.apply(
					{},
					options,
					{
						filterGroup: createEqualFilterGroup({
							filters: {
								Id: options.id
							}
						})
					}
				)
			);
		}

		/**
		 * @class EdenLab.utils.db
		 * Class with utility methods for db queries
		 */
		Ext.define("EdenLab.utils.db", {

			alternateClassName: "EL.utils.db",

			singleton: true,

			createEqualFilterGroup: createEqualFilterGroup,
			addESQColumns: addESQColumns,
			createESQ: createESQ,
			getItemsFromDB: getItemsFromDB,
			setLookupValueByFilterGroup: setLookupValueByFilterGroup,
			setLookupValueById: setLookupValueById
		});

		return EdenLab.utils.db;
	}
);