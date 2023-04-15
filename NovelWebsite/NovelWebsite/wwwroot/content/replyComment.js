function replyComment(el) {
    var id = '#' + el;
    var user = GetUserInfo();
    const newDivElement = $('<div>', {
        class: 'user--discussion-child'
    });
    const newUlElement = $('<ul>', {
        class: 'list-group list-group-flush'
    });

    $.ajax({
        url: "/Comment/GetReplyComment?commentId=" + el,
        type: "GET",
        dataType: "json",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            console.log(data);
            data.forEach((item) => {
                var content = $('<textarea />').html(item.content).text();
                newUlElement.append(`<li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="${item.user.avatar}">
                                            </a>
                                        </div>
                                        <div class="col user--discussion-main" id="${item.commentId}">
                                            <div class="user--discussion comment-group" id="comment-${item.commentId}">
                                                <p class="users">
                                                    <a href="javascript:void(0)">${item.user.userName}</a>
                                                </p>
                                                <p class="comments">
                                                    ${content}
                                                </p>
                                                <p class="info--wrap">
                                                    <span>${item.createdDate} </span>
                                                    
                                                    <a href="javascript:void(0)" id="comment-like-btn-${item.commentId}" onclick="onClickBtnLikeComment(this, ${item.commentId})">
                                                        <i class="fa-regular fa-thumbs-up info-icon"></i>
                                                        ${item.likes}
                                                    </a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </li>`);
            })

            newUlElement.append(`<li class="list-group-item">
                        <div class="row user--comment-section">
                            <div class="user--photo col-md-auto">
                                <a href="javascript:void(0)">
                                    <img src="${user.user.avatar}">
                                </a>
                            </div>                                       
                            <div class="input-comment col">
                                <div id="reply${el}-toolbar"></div>
                                <div id="reply${el}-editor" class="input--box"></div>
                            </div>
                            <div class="submit-btn col-md-12">
                                <div class="submit-btn-wrap">
                                    <button class="btn btn-primary" onclick="AddReplyComment(${el})">Đăng</button>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>`)
            newDivElement.append(newUlElement);
            $(id).append(newDivElement);
            var toolbar = 'reply' + el + '-toolbar';
            var editor = 'reply' + el + '-editor';
            startCKEditor(toolbar, editor);
        }
    });

    CommentUserLike();
}

function startCKEditor(toolbar, editor) {
    DecoupledEditor
        .create(document.querySelector('#' + editor), {
            toolbar: {
                items: [
                    'selectAll', '|',
                    'heading', '|',
                    'bold', 'italic', 'strikethrough', 'underline', '|',
                    'bulletedList', 'numberedList', '|',
                    'outdent', 'indent', '|',
                    'undo', 'redo',
                    '-',
                    'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', '|',
                    'alignment', '|',
                    'link', 'blockQuote', 'insertTable', 'mediaEmbed', '|',
                ],
                shouldNotGroupWhenFull: true
            },
            // Changing the language of the interface requires loading the language file using the <script> tag.
            language: 'vi',
            list: {
                properties: {
                    styles: true,
                    startIndex: true,
                    reversed: true
                }
            },

            heading: {
                options: [
                    { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                    { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                    { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                    { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                    { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                    { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                    { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' }
                ]
            },

            // placeholder: 'Welcome to CKEditor 5!',

            fontFamily: {
                options: [
                    'default',
                    'Arial, Helvetica, sans-serif',
                    'Courier New, Courier, monospace',
                    'Georgia, serif',
                    'Lucida Sans Unicode, Lucida Grande, sans-serif',
                    'Tahoma, Geneva, sans-serif',
                    'Times New Roman, Times, serif',
                    'Trebuchet MS, Helvetica, sans-serif',
                    'Verdana, Geneva, sans-serif'
                ],
                supportAllValues: true
            },

            fontSize: {
                options: [10, 12, 14, 'default', 18, 20, 22],
                supportAllValues: true
            },

        })
        .then(editor => {
            const toolbarContainer = document.querySelector('#' + toolbar);

            toolbarContainer.prepend(editor.ui.view.toolbar.element);

            window.editor = editor;
        })
        .catch(err => {
            console.error(err.stack);
        });

}
