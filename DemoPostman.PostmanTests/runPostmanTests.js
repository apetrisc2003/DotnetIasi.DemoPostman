var newman = require('newman');
var endpoint = process.argv[2];
newman.run({
	collection: 'DemoPostman.postman_collection.json',
	globals: {
		"values": [{
				"key": "endpoint",
				"value": endpoint,
				"enabled": true,
				"type": "text"
			}
		]
	},
	environment: 'DemoPostman.postman_environment.json',
	// reporters: 'myreporter',
	// reporter: {
		// myreporter: {
			// 'option-name': 'option-value' //thisisoptional
		// }
	// }
},
	function (err, summary) {
	if (err) {
		throw err;
	}
	console.info('collection run complete!');
});
