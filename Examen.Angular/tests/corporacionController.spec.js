describe('corporacionController', function () {
    var controller, service;

    beforeEach(function () { module('app') });

    beforeEach(inject(function ($controller, _dataService_, $q) {
        service = _dataService_;

        spyOn(service, "getData").and.callFake(function () {
            var deferred = $q.defer();
            deferred.resolve('Response');
            return deferred.promise;
        });

        controller = $controller('corporacionController', {
            dataService: service
        });

    }));

    describe('Corporacion Test', function () {
        it('Corporaciones', inject(function () {
            controller.list();
            expect(controller.corporacionList.length).toBeGreaterThan(0);
        }));
    });

});