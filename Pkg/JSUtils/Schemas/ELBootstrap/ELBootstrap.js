(function () {

  var preLoadDeps = [
    "el-service-provider",
    "el-sys-settings",
    "el-select-query",
    "el-entity-schema-query",
    "el-base-query",
    "el-right-utils",
    "el-filter-group"
  ];

  var deps;
  var bootstrapModuleNames = Terrasoft.preLoadedSysSettings.ELBootstrapModules.value;
  if (bootstrapModuleNames) {
    var transpilerModule = "ELJSTranspilerLoader";
    deps = bootstrapModuleNames.split(",").concat(preLoadDeps);
    if (requirejs.s.contexts._.config.paths.hasOwnProperty(transpilerModule)) {
      deps = deps.map(function (n) {
        return transpilerModule + "!" + n;
      });
    }
  }

  require.config({
    paths: {
      "el-service-provider": Terrasoft.getFileContentUrl("JSUtils", "src/js/el-service-provider.js"),
      "el-sys-settings": Terrasoft.getFileContentUrl("JSUtils", "src/js/el-sys-settings.js"),
      "el-select-query": Terrasoft.getFileContentUrl("JSUtils", "src/js/el-select-query.js"),
      "el-entity-schema-query": Terrasoft.getFileContentUrl("JSUtils", "src/js/el-entity-schema-query.js"),
      "el-base-query": Terrasoft.getFileContentUrl("JSUtils", "src/js/el-base-query.js"),
      "el-right-utils": Terrasoft.getFileContentUrl("JSUtils", "src/js/el-right-utils.js"),
      "el-filter-group": Terrasoft.getFileContentUrl("JSUtils", "src/js/el-filter-group.js")
    }
  });

  define(deps);
})();