import React, { Component } from "react";
import { Route } from "react-router";

export class SiteHeader extends Component {
    render() {
        return (
            <div className="pg-header">
                <div className="header-container">

                    <header className="header-top disp-flex">
                        <router-link to="/" class="header-logo">
                            <img alt="News Lines" src="/img/logo_1.png" />
                            <h1>News Lines</h1>
                        </router-link>
                        <div className="header-top-tools">
                            <div name="header-search-form" className="header-search-form clearfix">
                                <input className="header-input-search" id="input-main-search" />
                                <a className="header-search-button">
                                    <i className="fa fa-search"></i>
                                </a>
                            </div>
                        </div>
                    </header>

                    <div className="header-bottom">
                        <nav className="main-navigation">
                            <ul className="main-navigation-list clearfix">
                                <li><a to="/"><strong>Home</strong></a></li>
                                <li><a to="/category/10007" ><strong>World</strong></a></li>
                                <li><a to="/category/10005" ><strong>Politics</strong></a></li>
                                <li><a to="/category/10006" ><strong>Business</strong></a></li>
                                <li><a to="/category/10008" ><strong>Sports</strong></a></li>
                                <li><a to="/category/10009" ><strong>Tech</strong></a></li>
                                <li><a to="/category/10010" ><strong>Health</strong></a></li>
                            </ul>
                        </nav>
                    </div>

            </div>
        </div >
            
        );
    }
}