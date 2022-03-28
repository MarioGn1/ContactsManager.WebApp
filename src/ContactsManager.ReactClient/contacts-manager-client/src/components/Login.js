import { useNavigate, NavLink } from 'react-router-dom';


const Login = () => {
    let navigate = useNavigate();

    const submit = (e) => {
        e.preventDefault();

        // TODO: Login

        navigate('/');
    };

    return (
        <>
            <section id="login-page" className="auth">
                <form id="login" onSubmit={submit}>

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
                <span>If you don't have profile click <NavLink className="active-navigation-link" to="/register">here</NavLink></span>
            </p>
        </>

    );
}

export default Login;