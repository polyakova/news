/// <reference path="typings/jquery.d.ts"/>
/// <reference path="typings/jquery.tmpl.d.ts"/>
/// <reference path="models.ts"/>

class Feed {

	private _feedContainer: JQuery;
	private _sourcesContainer: JQuery;
	private _topic: string;

	public constructor(feed: JQuery, sources: JQuery) {

		this._feedContainer = feed;
		this._sourcesContainer = sources;

		this._topic = $('#topic').val();

		this.articles();
		this.sources();
	}

	private articles(): void {

		let url = '/api/news/articles';

		if (this._topic)
			url += '?topic=' + this._topic;

		this._feedContainer.addClass('loading');

		$.getJSON(url, (response: Articles[]) => {

			$.each(response, (i, item: Articles) => {

				let articles = item.articles.splice(0, 5);

				$.each(articles, (i, article: Article) => {

					article.publishedAt = new Date(article.publishedAt).toLocaleString();
					$('#article').tmpl(article).appendTo(this._feedContainer);
				});
			});

			this._feedContainer.removeClass('loading');
		});
	};

	private sources(): void {

		$.getJSON('/api/news/sources', (response: Sources) => {

			if (response.status == "ok")
			{
				$.each(response.sources, (i, source: Source) => {

					let visible = true;

					if (this._topic && this._topic != source.category)
						visible = false;

					if (visible)
						$('#source').tmpl(source).appendTo(this._sourcesContainer);

				});
			}
		});
	}
}

$((): void => {
	new Feed($('.feed'), $('.sources'));
})