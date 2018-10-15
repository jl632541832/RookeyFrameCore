var detailview = $.extend({}, $.fn.datagrid.defaults.view, {
    render: function (target, container, frozen) {
        var state = $.data(target, 'datagrid');
        var opts = state.options;
        var rows = state.data.rows;
        var fields = $(target).datagrid('getColumnFields', frozen);

        if (frozen) {
            if (!(opts.rownumbers || (opts.frozenColumns && opts.frozenColumns.length))) {
                return;
            }
        }

        var table = ['<table class="datagrid-btable" cellspacing="0" cellpadding="0" border="0"><tbody>'];
        for (var i = 0; i < rows.length; i++) {
            // get the class and style attributes for this row
            var css = opts.rowStyler ? opts.rowStyler.call(target, i, rows[i]) : '';
            var classValue = '';
            var styleValue = '';
            if (typeof css == 'string') {
                styleValue = css;
            } else if (css) {
                classValue = css['class'] || '';
                styleValue = css['style'] || '';
            }

            var cls = 'class="datagrid-row ' + (i % 2 && opts.striped ? 'datagrid-row-alt ' : ' ') + classValue + '"';
            var style = styleValue ? 'style="' + styleValue + '"' : '';
            var rowId = state.rowIdPrefix + '-' + (frozen ? 1 : 2) + '-' + i;
            table.push('<tr id="' + rowId + '" datagrid-row-index="' + i + '" ' + cls + ' ' + style + '>');
            table.push(this.renderRow.call(this, target, fields, frozen, i, rows[i]));
            table.push('</tr>');
        }
        table.push('</tbody></table>');

        $(container).html(table.join(''));
    },

    updateRow: function (target, rowIndex, row) {
        var dc = $.data(target, 'datagrid').dc;
        var opts = $.data(target, 'datagrid').options;
        var cls = $(target).datagrid('getExpander', rowIndex).attr('class');
        $.fn.datagrid.defaults.view.updateRow.call(this, target, rowIndex, row);
        $(target).datagrid('getExpander', rowIndex).attr('class', cls);

        // update the detail content
        if (this.canUpdateDetail && $(target).attr('nud') != '1') {
            var row = $(target).datagrid('getRows')[rowIndex];
            var detail = $(target).datagrid('getRowDetail', rowIndex);
            detail.html(opts.detailFormatter.call(target, rowIndex, row));
        }
    },
});