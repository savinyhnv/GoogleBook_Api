define(
	"BaseModalBoxPageLoaderModule",
	[
		"BaseSchemaModuleV2"
	],
	function() {
		/**
		 * @class EdenLab.preloadedModules
		 * Class for load modules in modal box
		 */
		Ext.define("EdenLab.utils.ui.BaseModalBoxPageLoaderModule", {
			extend: "Terrasoft.BaseSchemaModule",
			alternateClassName: "EL.utils.ui.BaseModalBoxPageLoaderModule",

			/**
			 * @inheritDoc Terrasoft.BaseSchemaModule#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				var schemaName = (this.parameters || {}).schemaName;
				this.schemaName = schemaName;
			},

			/**
			 * @inheritDoc Terrasoft.BaseSchemaModule#initHistoryState
			 * @overridden
			 */
			initHistoryState: Ext.emptyFn,

			/**
			 * @inheritDoc Terrasoft.BaseSchemaModule#createViewModel
			 * @overridden
			 */
			createViewModel: function(viewModelClass) {
				var viewModel = this.callParent(arguments);
				this.setViewModelDefaultValues(viewModel, this.parameters);
				return viewModel;
			},

			/**
			 * Set view model default parameter before init
			 * @param {Terrasoft.BaseViewModel} viewModel - Model for set attribute values
			 * @param {Object} parameters - Config with data for set attribute values in view model
			 */
			setViewModelDefaultValues: function(viewModel, parameters) {
				var viewModelData = (parameters || {}).data;
				this.Terrasoft.each(viewModelData, function(value, key) {
					viewModel.set(key, value);
				}, this);
			}
		});

		return EdenLab.utils.ui.BaseModalBoxPageLoaderModule;
	}
);
