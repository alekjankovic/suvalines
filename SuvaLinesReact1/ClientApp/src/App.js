import React, { Component } from 'react';
//import { Route } from 'react-router';

import { SiteHeader } from './components/SiteHeader';


//import { Layout } from './components/Layout';
//import { Home } from './components/Home';
//import { FetchData } from './components/FetchData';
//import { Counter } from './components/Counter';





//export default class App extends Component {
//  displayName = App.name

//  render() {
//    return (
//      <Layout>
//        <Route exact path='/' component={Home} />
//        <Route path='/counter' component={Counter} />
//        <Route path='/fetchdata' component={FetchData} />
//      </Layout>
//    );
//  }
//}


export default class App extends Component {
    render() {
        return (
            <div>
                <SiteHeader />
            </div>  
        );
    }
}