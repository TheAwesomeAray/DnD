import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import {BrowserRouter, Route} from 'react-router-dom';
import * as Redux from 'redux';
import * as ReactRedux from 'react-redux';
import { composeWithDevTools } from 'redux-devtools-extension';

const characters = [
    { name: 'Ilin' },
    { name: 'Kagor' },
    { name: 'Bellocke' }
];

const characterAdded = false;

function reducer(state = {characters, characterAdded},
action) {
    switch (action.type) {
        case 'CHARACTER_ADDED':
            return Object.assign(
                {}, 
                state, {
                    characters: state.characters.concat([action.character]),
                    characterAdded: true
            });
        default: return state;
    }
}
 
function logger({ getState }) {
    return next => action => {
      //console.log('will dispatch', action)
  
      // Call the next dispatch method in the middleware chain.
      const returnValue = next(action)
  
      //console.log('state after dispatch', getState())
  
      // This will likely be the action itself, unless
      // a middleware further in chain changed it.
      return returnValue
    }
  }

let store = Redux.createStore(reducer, composeWithDevTools(
    Redux.applyMiddleware(logger)
));

ReactDOM.render(
    <BrowserRouter>
        <React.Fragment>
            <ReactRedux.Provider store={store}>
                <Route exact path="/" component={App}/>
                <Route exact path="/StoryMode" component={App}/>
            </ReactRedux.Provider>
        </React.Fragment>
    </BrowserRouter>
, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
