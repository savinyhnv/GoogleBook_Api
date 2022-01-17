(function() {
	requirejs.config({shim: {ELBabelPolyfillLib: {deps: []}}});
	define(
		["ELJSTranspilerConfig", "ELBabelLib", "ELBabelPolyfillLib", "ELFetchPolyfillLib"],
		function(configModule, babel) {
			return {
				create: function(transpilerConfig) {
					requirejs.config({elTranspiler: Object.assign({}, transpilerConfig || configModule || {})});
					return {
						load: function(name, localRequire, onload, config) {
							var currentConfig = config.elTranspiler || transpilerConfig || configModule || {};
							if (currentConfig.plugin.isEnabled) {
								if (require.defined(name)) {
									require.undef(name);
								}
								var fileName = name + ".js";
								fetch(localRequire.toUrl(fileName))
									.then(function(r) {return r.text();})
									.then(function(r) {
										try {
											r = babel.transform(
												r, Object.assign({sourceFileName: fileName}, currentConfig.babel || {})
											).code;
										} catch (ex) {
											onload.error(ex);
										}
										onload.fromText(r);
									});
							} else {
								localRequire([name], onload);
							}
						}
					};
				}
			};
		}
	);
})();
