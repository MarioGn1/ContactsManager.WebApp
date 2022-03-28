import { NavLink } from 'react-router-dom';
import './Header.css';

const Header = () => {
    return (
        <header>
            <h1><NavLink className="home" to="/">Contacts Manager</NavLink></h1>
            <nav>
                <NavLink className="active-navigation-link" to="/contacts">Contacts</NavLink>
                <div id="user">
                    <NavLink className="active-navigation-link" to="/create-contact">Create</NavLink>
                    <NavLink className="active-navigation-link" to="/logout">Logout</NavLink>
                </div>
                <div id="guest">
                    <NavLink className="active-navigation-link" to="/login">Login</NavLink>
                    <NavLink className="active-navigation-link" to="/register">Register</NavLink>
                </div>
            </nav>
        </header>
    );
};

export default Header;