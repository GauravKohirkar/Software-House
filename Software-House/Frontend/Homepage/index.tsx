import * as ReactDom from 'react-dom';
import * as React from 'react';

import Demo from './Components/Demo/Demo'

ReactDom.render(
    <Demo />,
    document.getElementById('react-homepage-root')
)

declare var module: any;
if (module.hot) {
    module.hot.accept();
}