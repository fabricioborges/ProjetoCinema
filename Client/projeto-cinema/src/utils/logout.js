export default function logout(history){
    localStorage.clear();
    history.push('/');
}