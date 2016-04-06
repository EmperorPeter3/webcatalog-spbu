(function () {
    'use strict';

    var studyCatalogServices = angular.module('studyCatalogServices', ['ngResource']);

    studyCatalogServices.factory('ShakespeareLines', ['$resource',
      function ($resource) {

          var initRpud = $resource('/api/RPUDs/Filter', {}, {
              query: { method: 'GET', params: {} }
          });

      
         
          var initRpudWithParameters = $resource('/api/RPUDs/Filter', {}, {
              query: { method: 'GET', params: {} }
          });

          var keywordsSearch = $resource('/api/RPUDs/Search', {}, {
              query: { method: 'GET', params: {} }
          });
          return {
              initRpud: initRpud,
              initRpudWithParameters: initRpudWithParameters,
              keywordsSearch : keywordsSearch
          }
      }
    ]);
     

     

})();