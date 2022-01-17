define("ELBusinessRulesUtils", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
		/**
		 * Returns config for required always business rule, specially useful for editable details
		 * @returns {Object}
		 */
		function getRequiredAlwaysRule() {
			return {
				ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
				property: BusinessRuleModule.enums.Property.REQUIRED,
				conditions: [
					{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						},
						comparisonType: Terrasoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}
				]
			};
		}
		
		/**
		 * Returns config for not enabled always business rule, specially useful for editable details
		 * @returns {Object}
		 */
		function getDisabledAlwaysRule() {
			return {
				ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
				property: BusinessRuleModule.enums.Property.ENABLED,
				conditions: [
					{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: false
						},
						comparisonType: Terrasoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}
				]
			};
		}

		/**
		 * Returns config for filtration business rule
		 * @param {string} filterableEntityColumnName - column name of lookup entity
		 * @param {string} compareToColumnName - column name of current entity
		 * @param {Object} [options] - custom config that will be merged with base config
		 * @returns {Object}
		 */
		function getFiltrationRule(filterableEntityColumnName, compareToColumnName, options) {
			return Ext.merge({
				ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
				autocomplete: true,
				autoClean: true,
				baseAttributePatch: filterableEntityColumnName,
				comparisonType: Terrasoft.ComparisonType.EQUAL,
				type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
				attribute: compareToColumnName
			}, options || {});
		}

		/**
		 * @class EdenLab.utils.rules
		 * Class with business rules utility methods
		 */
		Ext.define("EdenLab.utils.rules", {

			alternateClassName: "EL.utils.rules",

			singleton: true,

			getRequiredAlwaysRule: getRequiredAlwaysRule,
			getDisabledAlwaysRule: getDisabledAlwaysRule,
			getFiltrationRule: getFiltrationRule
		});

		return EdenLab.utils.rules;
	}
);