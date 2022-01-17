define("el-service-provider", [], () => {
  Ext.define("EdenLab.ServiceProvider", {
    async get(resource, request, timeout) {
      const config = this.prepareServiceRequest(timeout);
      config.method = "GET";
      let parameters = Object.getOwnPropertyNames(request).map(x => `${x}=${request[x]}`).join("&");

      config.url = Terrasoft.combinePath(
        Terrasoft.utils.uri.getConfigurationWebServiceBaseUrl(), "api", resource);
      if (!!parameters) {
        config.url += "?" + parameters;
      }

      return new Promise(resolve => {
        config.callback = config.callback.bind(this, resolve);
        Terrasoft.AjaxProvider.request(config);
      });
    },

    async post(resource, request, timeout) {
      const config = this.prepareServiceRequest(timeout);
      config.method = "POST";
      config.jsonData = (request.encodeData === false) ? request || {} : Ext.encode(request || {});
      config.url = Terrasoft.combinePath(
        Terrasoft.utils.uri.getConfigurationWebServiceBaseUrl(), "api", resource);
      return new Promise(resolve => {
        config.callback = config.callback.bind(this, resolve);
        Terrasoft.AjaxProvider.request(config);
      });
    },

    async put(resource, request, timeout) {
      const config = this.prepareServiceRequest(timeout);
      config.method = "PUT";
      config.jsonData = (request.encodeData === false) ? request || {} : Ext.encode(request || {});
      config.url = Terrasoft.combinePath(
        Terrasoft.utils.uri.getConfigurationWebServiceBaseUrl(), "api", resource);
      return new Promise(resolve => {
        config.callback = config.callback.bind(this, resolve);
        Terrasoft.AjaxProvider.request(config);
      });
    },

    prepareServiceRequest: function (timeout) {
      return {
        headers: this.getDefaultHeaders(),
        callback: function (resolveFn, request, success, response) {
          if (response.status === 500) {
            this.processInternalServerError();
            return;
          }

          const responseObject = Ext.isEmpty(response.responseText) ? {} : Terrasoft.decode(response.responseText);

          if (response.getResponseHeader("Web-Api")) {
            resolveFn.call(this, {
              success,
              data: responseObject
            }, response);
          } else {
            resolveFn.call(this, responseObject, response);
          }
        },
        timeout: Terrasoft.BaseServiceProvider.getRequestTimeout({
          data: { requestTimeout: timeout }
        })
      };
    },

    getDefaultHeaders: function () {
      return {
        "Accept": "application/json",
        "Content-Type": "application/json"
      };
    },

    processInternalServerError: function () {
      this.hideBodyMask();
      this.showInformationDialog("An error occured during request. Please, contact system administrator.");
    }
  });

  EdenLab.serviceProvider = Ext.create("EdenLab.ServiceProvider");

  return EdenLab.serviceProvider;
});