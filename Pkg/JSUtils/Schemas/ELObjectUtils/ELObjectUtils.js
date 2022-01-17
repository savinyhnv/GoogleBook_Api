define(
	"ELObjectUtils",
	[],
	function() {
		/**
		 * @class EdenLab.utils.db
		 * Class with utility methods for js objects
		 */
		Ext.define("EdenLab.utils.object", {

				alternateClassName: "EL.utils.object",

				singleton: true,

				/**
				 * Returns object with fields from mapping with appropriate values from data object.
				 * @param {Object} mapping Matching data object keys and new object keys.
				 * @param {Object} data Base object.
				 * @param {Object} [config]
				 * @param {Boolean} config.[isSkipEmpty] Remove empty data fields using Ext.isEmpty()
				 * @param {Function} config.[filterMethod] Function to exclude fields from input data.
				 * @return {Object}.
				 */
				map: function(mapping, data, config) {
					config = config || {};
					var results = {};
					var filterFn = (config.isSkipEmpty || config.filterMethod) && function(value) {
							return (!config.isSkipEmpty || !Ext.isEmpty(value)) &&
								(!config.filterMethod || config.filterMethod(value));
						};
					for (var key in data) {
						if (mapping[key] && (!filterFn || filterFn(data[key]))) {
							results[mapping[key]] = data[key];
						}
					}
					return results;
				}
			}
		);

		return EdenLab.utils.object;
	}
);
