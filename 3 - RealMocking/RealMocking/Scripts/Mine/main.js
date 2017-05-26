function getUserGreetingMessage(name, exclaim) {
    var greeting = TranslationService.Greetings[getCurrentLocale()];
    return greeting + ", " + name + (exclaim ? "!" : "");
}

function initPage() {
    $('#popup').show();
}