(function () {
    'use strict';

    angular
        .module('studyCatalogApp')
        .controller('studyCatalogController', studyCatalogController);

    studyCatalogController.$inject = ['$scope', 'ShakespeareLines'];

    function studyCatalogController($scope, ShakespeareLines) {

        ShakespeareLines.initRpud.query(function (queryResult) {

            

            var aggregates = GetRPUDAggregatesObject(queryResult.TermAggs);

            $scope.RPUDAggregates = aggregates;
            $scope.RPUDAggregatesCheckbox = GenerateCheckboxValuesForRPUDAggregates(aggregates);
            $scope.Data = queryResult.Data ? queryResult.Data : {};
            
            // Events
            $scope.keywords = '';
            $scope.isChecked = function (aggName, value) {
                return $scope.RPUDAggregatesCheckbox[aggName][value];
            }
            $scope.change = function (aggName, value) {
                $scope.RPUDAggregatesCheckbox[aggName][value] = !($scope.RPUDAggregatesCheckbox[aggName][value]);

                var requestParameters = GetRequestParameters($scope.RPUDAggregatesCheckbox);

                ShakespeareLines.initRpudWithParameters.query(requestParameters, function (response) {
                    $scope.RPUDAggregates = GetRPUDAggregatesObject(response.TermAggs);
                    $scope.Data = response.Data;
                })
            }
            $scope.submit = function () {
                var requestParameters = {};
                requestParameters.keywords = $scope.keywords.split(' ');
                ShakespeareLines.keywordsSearch.query(requestParameters, function(response){
                    $scope.RPUDAggregates = GetRPUDAggregatesObject(response.TermAggs);
                    $scope.Data = response.Data;
                })
            }
            //EndEvents
        });

           
        // Helpers
        function GetRPUDAggregatesObject(termAggs) {
            var RPUDAggregatesObject = {};

            angular.forEach(termAggs, function (aggregate, index) {

                RPUDAggregatesObject[aggregate.Name] = {};

                angular.forEach(aggregate.Value, function (key, value) {

                    RPUDAggregatesObject[aggregate.Name][value] = key;
                })

            });

            return RPUDAggregatesObject;
        }

        function GenerateCheckboxValuesForRPUDAggregates(RPUDAggregates) {
            var RPUDAggregatesCheckbox = {};
            angular.forEach(RPUDAggregates, function (aggregate, name) {
                RPUDAggregatesCheckbox[name] = {};

                angular.forEach(aggregate, function (count, value) {
                    RPUDAggregatesCheckbox[name][value] = false;
                })
            });

            return RPUDAggregatesCheckbox;
        };

        function GetRequestParameters(checkboxes) {
            var requestParameters = {};
            angular.forEach(checkboxes, function (value, agg) {
                angular.forEach(value, function (isChecked, name) {

                    if (isChecked == true) {
                        if (requestParameters[agg] == undefined)
                            requestParameters[agg] = [];

                        requestParameters[agg].push(name);
                    }
                })
            });
            return requestParameters;

        }
        //EndHelpers
    }
})();
