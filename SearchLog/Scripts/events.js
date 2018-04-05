$(document).on('change', '.js-directory', function (e) {
    var $select = $(this);
    var actionUrl = $select.data('action');
    var $partialViewContainer = $($select.data('partial-view-container'));
    $.get(actionUrl + '?directoryPath=' + $select.val(), function (partiaView) {
        $partialViewContainer.empty();
        $partialViewContainer.append($(partiaView));
    });
});

$(document).on('click', '.js-btn-directory', function () {
    var $btn = $(this);
    var $searchInput = $($btn.data('search-input'));
    var $directory = $($btn.data('directory'));
    var $partialViewContainer = $($btn.data('partial-view-container'));

    $.get($btn.data('action') + '?directoryPath=' + $directory.val() + '&searchText=' + $searchInput.val(), function (partialView) {
        $partialViewContainer.empty();
        $partialViewContainer.append($(partialView));
    });
});