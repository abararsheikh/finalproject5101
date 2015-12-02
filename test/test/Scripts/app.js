(function () {
'use strict';

angular.module('doctorSearch', ['ngAnimate'])
.controller('SearchController', function ($http) {
    var search = this;
    search.currentList = 'doctors';
    
    search.setList = function (listName) {
        search.currentList = listName;
        $http({
            url: 'getData.aspx',
            method: 'GET',
            params: { t: listName }
        }).then(function (response) {
            search.list = response.data;
        });
    };

    search.setList(search.currentList);

    search.searchText = '';
    search.toggleDetail = function (person) {
        person.showDetail = !person.showDetail;
    };
    search.searchFilter = function (person) {
        if (search.searchText === ''){
            return true;
        }else{
            return person.first_name.toLowerCase().indexOf(search.searchText.toLowerCase()) !== -1 ||
                person.last_name.toLowerCase().indexOf(search.searchText.toLowerCase()) !== -1;
        }
    };
});



//end
})();
