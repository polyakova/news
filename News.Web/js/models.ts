
interface Source {
	id: string,
	category: string,
	urlsToLogos: string,
	name: string
	url: string;
}

interface Sources {
	status: string,
	sources: Source[]
}

interface Article {
	author: string,
	title: string,
	description: string,
	url: string,
	publishedAt: string;
}

interface Articles {
	status: string,
	articles: Article[],
	source: string
}