"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var dog_service_1 = require("./dog.service");
describe('DogService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(dog_service_1.DogService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=dog.service.spec.js.map