import { useNavigate, NavLink } from 'react-router-dom';


const Login = ({
    history
}) => {
    let historyHook = useNavigate();

    const onFormSubmit = (e) => {
        e.preventDefault();

        // TODO: Login

        history.push('/')
        // historyHook.push('/games');
    };

    return (
        <>
            <section id="login-page" className="auth">
                <form id="login" onSubmit={onFormSubmit}>

                    <div className="container">
                        <div className="brand-logo"></div>
                        <h1>Login</h1>
                        <label htmlFor="email">Email:</label>
                        <input type="email" id="email" name="email" placeholder="Sokka@gmail.com" />

                        <label htmlFor="login-pass">Password:</label>
                        <input type="password" id="login-password" name="password" />
                        <input type="submit" className="btn submit" value="Login" />

                    </div>
                </form>
            </section>
            <p className="field">
                <span>If you don't have profile click <NavLink activeClassName="active-navigation-link" to="/register">here</NavLink></span>
            </p>
        </>

    );
}

export default Login;