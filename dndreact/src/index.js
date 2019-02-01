import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import * as serviceWorker from './serviceWorker';
import {BrowserRouter, Route} from 'react-router-dom';
import * as Redux from 'redux';
import * as ReactRedux from 'react-redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import CharacterMenu from './CharacterMenu';
import StoryMode from './StoryMode';

const characters = [
    { name: 'Ilin',
    abilityScores: [
        { name: 'Strength', value: 8 },
        { name: 'Dexterity', value: 13 },
        { name: 'Constitution', value: 10 },
        { name: 'Intelligence', value: 18 },
        { name: 'Wisdom', value: 16 },
        { name: 'Charisma', value: 17 }
    ], },
    { name: 'Kagor',
    abilityScores: [
        { name: 'Strength', value: 20 },
        { name: 'Dexterity', value: 17 },
        { name: 'Constitution', value: 14 },
        { name: 'Intelligence', value: 11 },
        { name: 'Wisdom', value: 6 },
        { name: 'Charisma', value: 12 }
    ], },
    { name: 'Bellocke',
    abilityScores: [
        { name: 'Strength', value: 6 },
        { name: 'Dexterity', value: 5 },
        { name: 'Constitution', value: 11 },
        { name: 'Intelligence', value: 14 },
        { name: 'Wisdom', value: 19 },
        { name: 'Charisma', value: 17 }
    ], }
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
      console.log('will dispatch', action)
  
      // Call the next dispatch method in the middleware chain.
      const returnValue = next(action)
  
      console.log('state after dispatch', getState())
  
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
                <Route exact path="/" component={CharacterMenu}/>
                <Route exact path="/StoryMode" component={StoryMode}/>
            </ReactRedux.Provider>
        </React.Fragment>
    </BrowserRouter>
, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
