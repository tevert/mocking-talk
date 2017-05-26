describe('getUserGreetingMessage in Spanish', function () {
    beforeEach(function () {
        spyOn(window, 'getCurrentLocale').and.returnValue('es');
    });
    var message;

    describe('when the name is Amanda and we\'re exclaiming', function () {
        var name = "Amanda";
        var exclaim = true;

        beforeEach(function () {
            message = getUserGreetingMessage(name, exclaim);
        });

        it('returns the correct message', function () {
            expect(message).toBe('Hola, Amanda!');
        });

        it('calls the locale service', function () {
            expect(window.getCurrentLocale.calls.count()).toBe(1);
        });
    });

    describe('when the name is Tyler and we\'re not exclaiming', function () {
        var name = "Tyler";
        var exclaim = false;

        beforeEach(function () {
            message = getUserGreetingMessage(name, exclaim);
        });

        it('returns the correct message', function () {
            expect(message).toBe('Hola, Tyler');
        });

        it('calls the locale service', function () {
            expect(window.getCurrentLocale.calls.count()).toBe(1);
        });
    });

    describe('when the name is Scott and we\'re not passing the exclaim arg', function () {
        var name = "Scott";

        beforeEach(function () {
            message = getUserGreetingMessage(name);
        });

        it('returns the correct message', function () {
            expect(message).toBe('Hola, Scott');
        });

        it('calls the locale service', function () {
            expect(window.getCurrentLocale.calls.count()).toBe(1);
        });
    });
});

describe('initPage', function () {
    beforeEach(function () {
        spyOn(window.$.fn, 'show');
        spyOn(window, '$').and.callThrough();
    });

    beforeEach(function () {
        initPage();
    });

    it('looks for the popup and only the popup', function () {
        expect(window.$.calls.count()).toBe(1);
        expect(window.$).toHaveBeenCalledWith('#popup');
    });

    it('calls "show"', function () {
        expect(window.$.fn.show.calls.count()).toBe(1);
    });
});